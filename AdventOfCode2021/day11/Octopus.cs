namespace day11
{
    public class Octopus
    {
        private int x;
        private int y;
        private int power;
        private bool alreadyFlashed;

        public Octopus(int y, int x, int startPower)
        {
            this.y = y;
            this.x = x;
            this.power = startPower;
            alreadyFlashed = false;
        }

        public int increasePower(Field field)
        {
            int flashes = 0;
            if (alreadyFlashed)
            {
                return 0;
            }
            power++;
            if (power >= 10)
            {
                power -= 10;
                alreadyFlashed = true;
                flashes++;

                if (field.isInField(y + 1, x))
                {
                    flashes += field.getOctopus(y + 1, x).increasePower(field);
                }
                
                if (field.isInField(y - 1, x))
                {
                    flashes += field.getOctopus(y - 1, x).increasePower(field);
                }
                
                if (field.isInField(y, x + 1))
                {
                    flashes += field.getOctopus(y, x + 1).increasePower(field);
                }
                
                if (field.isInField(y, x - 1))
                {
                    flashes += field.getOctopus(y, x - 1).increasePower(field);
                } 
                
                if (field.isInField(y + 1, x + 1))
                {
                    flashes += field.getOctopus(y + 1, x + 1).increasePower(field);
                }
                
                if (field.isInField(y - 1, x + 1))
                {
                    flashes += field.getOctopus(y - 1, x + 1).increasePower(field);
                }
                
                if (field.isInField(y - 1, x - 1))
                {
                    flashes += field.getOctopus(y - 1, x - 1).increasePower(field);
                }
                
                if (field.isInField(y + 1, x - 1))
                {
                    flashes += field.getOctopus(y + 1, x - 1).increasePower(field);
                }
                return flashes;
            }
            
            return 0;
        }

        public void resetFlash()
        {
            alreadyFlashed = false;
        }

        public int getPower()
        {
            return power;
        }
    }
    
    
}