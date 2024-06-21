using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckStudent.Repository.DTO.StudentFace
{
    public class StudentFaceDTO
    {
        public int Id { get; set; }
        public byte[] FaceData { get; set; }
        public DateTime? CaptureDate { get; set; }
        public int StudentId { get; set; }
    }
}
