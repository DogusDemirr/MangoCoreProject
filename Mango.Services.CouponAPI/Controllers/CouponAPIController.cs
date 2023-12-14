﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Constants;
using Mango.Services.CouponAPI.Models.Dto;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDto _response;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                string logMessage = $"Hata oluştu :{_response.Message}";
                string logFolderPath = Constant.FILE_PATH;
                string logFilePath = Path.Combine(logFolderPath, "error_log.txt");

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} - {logMessage}\n{ex.StackTrace}");
                }
            }
            return _response;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _response.Result  = _mapper.Map<Coupon>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                string logMessage = $"Hata oluştu :{_response.Message}";
                string logFolderPath = Constant.FILE_PATH;
                string logFilePath = Path.Combine(logFolderPath, "error_log.txt");

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} - {logMessage}\n{ex.StackTrace}");
                }
            }
            return _response;
        }
    }
}
