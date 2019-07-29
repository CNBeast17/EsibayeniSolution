using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EsibayeniSolution.Models
{
    public class LivesStock
    {
        public LivesStock()
        {
        
        }
        //Constructor used for auto-creation of livestock 
        public LivesStock(Batch batch, Category category)
        {

            BatchID = batch.BatchID;
            CategoryId = batch.CategoryID;
            CostPrice = calcUnitCost(batch);
            Code = GenerateCode(category);

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Livestock ID")]
        public int LivestockID { get; set; }
        [DisplayName("Code")]
        public string Code { get; set; }
        [DisplayName("Type")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [DisplayName("Batch No")]
        public int? BatchID { get; set; }
        public virtual Batch Batch { get; set; }
        public decimal Weight { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        [DisplayName("Cost Price")]
        public decimal CostPrice { get; set; }

        public string GenerateCode(Category category)
        {
            string type = category.CategoryType;
            string code = "L" + type.Substring(0, 1) + type.Substring(type.Length - 1, 1);
            return code.ToUpper()+LivestockID;
        }
        public decimal calcUnitCost(Batch batch)
        {
            return batch.BatchCost / batch.Quantity;
        }
    }
}