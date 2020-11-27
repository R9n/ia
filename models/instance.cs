namespace iac.models
{
    public class Instance
    {
        private Node solution;
        private Node InitialSate;

        public Instance(Node initialState,Node solution)
        {
            setSolution(initialState);
            setSolution(solution);
            
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