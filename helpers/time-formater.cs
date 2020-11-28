namespace iac.helpers
{
    public static class TimeFormatter
    {
        public static string format(double time)
        {

            if (time < 1000)
            {
                return (time + " Milisegundos");
            }
           if (time >= 1000 && time < 60000)
           {
               return ((time / 1000) + " Segundos");
           }
           if (time >= 60000 && time < 3600000)
           {
               return ((time / 60000) + " Minutos");
           }
           
           if (time >= 60000 && time < 86400000)
           {
               return ((time / 3600000) + " Horas");
           }
           
           return ((time / 86400000) + "dias");
        }
        
    }
}