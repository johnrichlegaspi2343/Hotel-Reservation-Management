using Model;

namespace BusinessLogic.Repository
{
    // Additional charges: extra bed, guest assistance, sira, nawala, atbp.
    public class ChargeRepository
    {
        public Charge? GetChargeById(int id)
        {
            using (var db = new AppDBContext())
            {
                return db.Charges.Find(id);
            }
        }

        public void AddCharge(Charge charge)
        {
            using (var db = new AppDBContext())
            {
                db.Charges.Add(charge);
                db.SaveChanges();
            }
        }

        public void DeleteCharge(int id)
        {
            using (var db = new AppDBContext())
            {
                Charge? charge = db.Charges.Find(id);
                if (charge != null)
                {
                    db.Charges.Remove(charge);
                    db.SaveChanges();
                }
            }
        }
    }
}