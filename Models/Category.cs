using System.ComponentModel.DataAnnotations;

namespace AspNetCoreFood.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
   
        public string CategoryDescription { get; set; }

        public List<Food> Foods { get; set; }

        public bool Status { get; set; } 
        /*
         İlişkili tablolarda veri silme hata verdiği için Aktif-Pasif özelliğini kullanıyoruz.
        Yani sildiğimiz kategorinin Status adlı sütununu false yapıyoruz.
         */

    }
}
