using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public abstract class ModelBaseViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int? IdUserCreate { get; set; }
        public int? IdUserDelete { get; set; }
        public int? IdUserUpdate { get; set; }
        public DateTime? DtUserCreate { get; set; }
        public DateTime? DtUserDelete { get; set; }
        public DateTime? DtUserUpdate { get; set; }
    }
}
