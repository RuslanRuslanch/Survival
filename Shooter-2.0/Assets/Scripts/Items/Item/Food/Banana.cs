namespace TSI.Items
{
    public class Banana : Food
    {
        public override bool TryEat()
        {
            Eat();

            return true;
        }

        protected override void Eat()
        {
            print("Banana eated");
        }
    }
}