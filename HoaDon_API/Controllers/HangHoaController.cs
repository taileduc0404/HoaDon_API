using HoaDon_API.Data;
using HoaDon_API.DTOs;
using HoaDon_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoaDon_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly hoadonContext _context;

        public HangHoaController(hoadonContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<Hanghoa>> GetAll()
        {
            var hanghoa = _context.Hanghoas.ToList();
            return hanghoa;
        }
        [HttpGet]
        public ActionResult<Hanghoa> GetById(string mahang)
        {
            var hanghoa = _context.Hanghoas.FirstOrDefault(x => x.Mahang == mahang);
            if (hanghoa == null)
            {
                return NotFound($"Not Found Ma hang {mahang}");
            }
            return hanghoa;
        }

        [HttpPost]
        public ActionResult Create(HangHoaDto dto)
        {
            Hanghoa hanghoa = new Hanghoa
            {
                Mahang = dto.Mahang,
                Tenhang = dto.Tenhang,
                Dvt = dto.Dvt,
                Dongia = dto.Dongia,
            };
            _context.Hanghoas.Add(hanghoa);
            _context.SaveChanges();
            return Ok("Create success");
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var hanghoaFind = _context.Hanghoas.FirstOrDefault(x => x.Mahang == id);
            if (hanghoaFind == null)
            {
                return NotFound($"Not found hang hoa {id}");
            }
            else
            {
                _context.Hanghoas.Remove(hanghoaFind);
                _context.SaveChanges();
                return Ok("Delete success");
            }

        }

        [HttpPut]
        public ActionResult Update(string mahang, HangHoaDto dto)
        {
            var hanghoaFind = _context.Hanghoas.FirstOrDefault(x => x.Mahang == mahang);
            if (hanghoaFind == null)
            {
                return NotFound($"Not found ma hang {mahang}");
            }
            else
            {
                hanghoaFind.Tenhang = dto.Tenhang;
                hanghoaFind.Dvt = dto.Dvt;
                hanghoaFind.Dongia = dto.Dongia;
                _context.Hanghoas.Update(hanghoaFind);
                _context.SaveChanges();
                return Ok("Update success");
            }
        }
    }
}
