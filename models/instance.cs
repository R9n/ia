namespace iac.models
{
    public class Instance
    {
        private Node solution;
        private Node InitialSate;
        private int dimension;

        public Instance(Node initialState,Node solution,int dimension)
        {
            setInitialState(initialState);
            setSolution(solution);
            setDimension(dimension);
            
            
        }

        
            
        public void setDimension(int value)
        {
            dimension = value;
        }
        public int getDimension()
        {
            return dimension;
        }
        public Node getSolution()
        {
            return solution;
        }
        public Node getInitialState()
        {
            return InitialSate;
        }

        public void setSolution(Node node)
        {
            solution = node;
        }
        
        public void setInitialState(Node node)
        {
            InitialSate = node;
        }

    }
}