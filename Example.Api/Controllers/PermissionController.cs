using AutoMapper;
using Example.Domain.Entities;
using Example.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Net;

namespace Example.Api.Controllers
{
    [Route("api/permission")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;
        private readonly IElasticClient _elasticClient;
        public PermissionController(IMapper mapper, IPermissionService permissionService, IElasticClient elasticClient)
        {
            _mapper = mapper;
            _permissionService = permissionService;
            _elasticClient = elasticClient;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(CustomResponse<IEnumerable<PermissionDto>>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> Index()
        //{
        //    var categories = await _permissionService.GetAllAsync();
        //    var response =
        //        new CustomResponse<IEnumerable<PermissionDto>>("Success", _mapper.Map<IEnumerable<PermissionDto>>(categories));
        //    return Ok(response);
        //}

        [HttpGet(Name = "GetPermission")]
        public async Task<IActionResult> Get(string keyword)
        {
            var results = await _elasticClient.SearchAsync<PermissionDto>(
                s => s.Query(
                    q => q.QueryString(
                        d => d.Query('*' + keyword + '*')
                        )
                    ).Size(1000)
                );

            return Ok(results.Documents.ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomResponse<PermissionDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Single(int id)
        {
            var permission = await _permissionService.GetByIdAsync(id);
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            var response = new CustomResponse<PermissionDto>("Success", permissionDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomResponse<PermissionDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create(PermissionDto dto)
        {
            var permission = _mapper.Map<Permission>(dto);
            await _permissionService.CreateAsync(permission);
            var response = new CustomResponse<PermissionDto>("Success", null);

            await _elasticClient.IndexDocumentAsync(permission);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CustomResponse<PermissionDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(PermissionDto dto)
        {
            var permission = _mapper.Map<Permission>(dto);
            await _permissionService.UpdateAsync(permission);
            var response = new CustomResponse<PermissionDto>("Success", null);
            return Ok(response);
        }
    }
}
