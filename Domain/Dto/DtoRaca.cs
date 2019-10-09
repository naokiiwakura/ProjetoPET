using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class DtoRaca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }


        public static explicit operator Raca(DtoRaca dto)
        {
            return new Raca() {
                Id = dto.Id,
                Descricao = dto.Descricao
            };
        }
    }
}
