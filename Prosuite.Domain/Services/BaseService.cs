using AutoMapper;
using Microsoft.Extensions.Logging;
using Prosuite.Domain.Constants;
using Prosuite.Domain.Contracts.Dtos.Requests;
using Prosuite.Domain.Contracts.Dtos.Responses;
using Prosuite.Domain.Contracts.Interfaces.Repositories;
using Prosuite.Domain.Contracts.Interfaces.Services.Domain;
using Prosuite.Domain.Contracts.Interfaces.Services.Infrastructure.Utils;
using Prosuite.Domain.Entities;
using Prosuite.Domain.Extensions;
using RestSharp;
using ResponseStatus = Prosuite.Domain.Constants.ResponseStatus;

namespace Prosuite.Domain.Services
{
    public abstract class BaseService<T, Response, Request, Filter>
        : IBaseService<T, Response, Request, Filter>
        where T : Entity where Response : class where Request : BaseRequest where Filter : FilterableRequest
    {
        protected ICommandRepository<T> _commandRepository;
        protected IQueryRepository<T> _queryRepository;
        protected ILogger<BaseService<T, Response, Request, Filter>> _logger;
        protected IValidatorBase<Request> _validator;
        protected readonly IMapper _mapper;
        protected readonly IJsonSerializationManager _serializer;


        public BaseService(
                            IValidatorBase<Request> validator,
                            IMapper mapper,
                            ICommandRepository<T> commandRepository,
                            IQueryRepository<T> queryRepository,
                            
                            IJsonSerializationManager serializer,
                            ILogger<BaseService<T, Response, Request, Filter>> logger)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _validator = validator;
            _mapper = mapper;
            _logger = logger;
            _serializer = serializer;
        }

        #region Create
        public async Task<DataResponse<Response>> Create(Request request)
        {
            var response = new DataResponse<Response>();
            try
            {
                var validationresults = _validator.Validate(request);

                if (!validationresults.Any())
                {
                    var newEntity = _mapper.Map<T>(request);

                    await _commandRepository.Create(newEntity);

                    response.Data = await PostCreate(newEntity);
                    response.StatusCode = ResponseStatus.Ok;
                }
                else
                {
                    foreach (var message in validationresults)
                    {
                        response.Messages.Add(new MessageResponse { Message = message, Type = MessageType.Validation });
                    }
                    response.StatusCode = ResponseStatus.BadRequest;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatus.ServerError;
                var errorMessage = $"Error occured when creating {typeof(T)}.";
                response.Messages.Add(new MessageResponse { Message = errorMessage, Type = MessageType.Technical });
                _logger.LogError(ex, errorMessage);
            }
            return response;
        }


        protected async virtual Task<Response> PostCreate(T entity) => _mapper.Map<Response>(entity);

        #endregion

        #region Update  
        public async Task<DataResponse<Response>> Update(Request request)
        {
            var response = new DataResponse<Response>();
            try
            {
                var validationresults = _validator.Validate(request);

                if (!validationresults.Any())
                {
                    var itemToUpdate = await _queryRepository.GetByPlainId(request.Id);
                    if (itemToUpdate != null)
                    {
                        var update = _mapper.Map<T>(request);

                        update.IsActive = itemToUpdate.IsActive;
                        update.CreatedAt = itemToUpdate.CreatedAt;
                        update.CreatedBy = itemToUpdate.CreatedBy;

                        var updateId = update.GetType().GetProperty("Id");
                        var idValue = itemToUpdate.GetType().GetProperty("Id");

                        if (idValue != null)
                            updateId.SetValue(update, idValue.GetValue(itemToUpdate));

                        await _commandRepository.Update(itemToUpdate, update);
                        response.Data = await PostUpdate(update);
                        response.StatusCode = ResponseStatus.Ok;
                    }
                    else
                        response.StatusCode = ResponseStatus.BadRequest;
                }
                else
                {
                    foreach (var message in validationresults)
                    {
                        response.Messages.Add(new MessageResponse { Message = message, Type = MessageType.Validation });
                    }
                    response.StatusCode = ResponseStatus.BadRequest;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatus.ServerError;
                var errorMessage = $"Error occured when updating {typeof(T).Name}.";
                response.Messages.Add(new MessageResponse { Message = errorMessage, Type = MessageType.Technical });
                _logger.LogError(ex, errorMessage);
            }
            return response;
        }


        protected async virtual Task<Response> PostUpdate(T entity) => _mapper.Map<Response>(entity);

        #endregion

        #region Read

        public PagedResponse<Response> Find(Filter request)
        {

            var response = new PagedResponse<Response>();
            try
            {
                var list = FindLogic(request);
                var getlist = list.ToList();
                var paged = list.Paginate(request.Page, request.Size);

                response.PageSize = paged.PageSize;
                response.CurrentPage = paged.CurrentPage;
                response.NextPage = paged.NextPage;
                response.PreviousPage = paged.PreviousPage;
                response.DisplayingText = paged.DisplayingText;
                response.TotalItems = paged.TotalItems;
                response.TotalPages = paged.TotalPages;
                response.Items = new List<Response>();

                foreach (var entity in paged.Items)
                {
                    response.Items.Add(_mapper.Map<Response>(entity));
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatus.ServerError;
                var errorMessage = $"Error occured when searching fro {typeof(T)}, search criteria{request}.";
                response.Messages.Add(new MessageResponse { Message = errorMessage, Type = MessageType.Technical });
                _logger.LogError(ex, errorMessage);
            }
            return response;
        }


        public async Task<DataResponse<Response>> Get(long id)
        {
            var response = new DataResponse<Response>();
            try
            {
                var itmToEdit = await _queryRepository.GetById(id);
                if (itmToEdit != null)
                {
                    response.Data = _mapper.Map<Response>(itmToEdit);
                    response.StatusCode = ResponseStatus.Ok;
                }
                else
                    response.StatusCode = ResponseStatus.NotFound;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatus.ServerError;
                var errorMessage = $"Error occured when reading from {typeof(T)},id={id}.";
                response.Messages.Add(new MessageResponse { Message = errorMessage, Type = MessageType.Technical });
                _logger.LogError(ex, errorMessage);
            }
            return response;
        }

        protected abstract IQueryable<T> FindLogic(Filter request);

        public async Task<DataResponse<List<Response>>> All()
        {
            var response = new DataResponse<List<Response>>();
            try
            {
                var list = await _queryRepository.GetAll();
                var lookUpList = new List<Response>();
                if (list != null && list.Any())
                {
                    foreach (var item in list)
                        lookUpList.Add(_mapper.Map<Response>(item));

                    response.Data = lookUpList;
                    response.StatusCode = ResponseStatus.Ok;
                }
                else
                    response.StatusCode = ResponseStatus.NotFound;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatus.ServerError;
                var errorMessage = $"Error occured when retrieving all records for {typeof(T)}";
                response.Messages.Add(new MessageResponse { Message = errorMessage, Type = MessageType.Technical });
                _logger.LogError(ex, errorMessage);
            }

            return response;
        }



        #endregion

        #region Delete
        public async virtual Task<BaseResponse> Delete(long id)
        {
            var response = new BaseResponse();
            try
            {
                var itemToDelete = await _queryRepository.GetByPlainId(id);
                if (itemToDelete != null)
                {
                    await _commandRepository.Delete(itemToDelete);
                    response.StatusCode = ResponseStatus.Ok;
                }
                else
                    response.StatusCode = ResponseStatus.NotFound;
            }
            catch (Exception ex)
            {
                response.StatusCode = Constants.ResponseStatus.ServerError;
                var errorMessage = $"Error occured when deleting {typeof(T).Name}, with Id {id}";
                response.Messages.Add(new MessageResponse { Message = errorMessage, Type = MessageType.Technical });
                _logger.LogError(ex, errorMessage);
            }
            return response;
        }




        #endregion
    }
}