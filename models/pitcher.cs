using System;

namespace iac.models

{
   
    public class Pitcher
    {
       
        public int getFreeSpace() {
            return _maxVolume - _currentVolume;
        }

        private bool _isFull;
        private int _currentVolume;
        private int _maxVolume;
        private int _id;
        private string _name;

        
        public void setId(int id)
        {
            this._id = id;
        }

        public int getId()
        {
            return this._id;
        }
        
        
        public void setName(string name)
        {
            _name = name;
        }

        public string getName()
        {
            return _name;
        }
        
        
        public void setMaxVolume(int volume)
        {
            this._maxVolume = volume;
        }

        public int getMaxVolume()
        {
            return this._maxVolume;
        }
        
        
        
        
        
        public void setIsFull(bool isFull)
        {
            this._isFull = isFull;
        }

        public bool getIsFull()
        {
            return this._isFull;
        } 
        
        public void setCurrentVolume(int volume)
        {
            this._currentVolume = volume;
        }

        public int getCurrentVolume()
        {
            return this._currentVolume;
        }



        public Pitcher(int currentVolume = 0, int maxVolume = 0, bool isFull = false)
        {
            _currentVolume = currentVolume;
            _maxVolume = maxVolume;
            _isFull = isFull;
            _id = Global_variables.idsHandler.getNextId();
        }
        
        public Pitcher(Pitcher pitcher)
        {

            _currentVolume = pitcher.getCurrentVolume();
            _maxVolume = pitcher.getMaxVolume();
            _isFull = pitcher.getIsFull();
            _name = pitcher.getName();
            _id = Global_variables.idsHandler.getNextId();
        }
        
    }
}