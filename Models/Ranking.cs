using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public enum Rank
    {
        Broze = 0,
        Silver = 1,
        Gold = 2
    }
    public class Ranking
    {
        [Key]
        public int RankId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Rank Rank { get; set; }
        public decimal SpentMoney { get; set; }
        public double Discount { get; set; }
        public Rank GetRank()
        {
            if (SpentMoney > 50)
            {
                Rank = Rank.Silver;
            }
            if (SpentMoney > 100)
            {
                Rank = Rank.Gold;
            }
            return Rank;
        }
        public double GetDiscount()
        {
            switch (Rank)
            {
                case Rank.Broze:
                    Discount = 5;
                    break;
                case Rank.Silver:
                    Discount = 10;
                    break;
                case Rank.Gold:
                    Discount = 20;
                    break;
            }
            return Discount;
        }
    }
    public class RankingResponse
    {
        [Key]
        public int RankId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Rank Rank { get; set; }
        public decimal SpentMoney { get; set; }

        public RankingResponse(Ranking rank)
        {
            RankId = rank.RankId;
            UserId = rank.UserId;
            UserName = rank.UserName;
            SpentMoney = rank.SpentMoney;
            Rank = rank.GetRank();
        }
    }


}
