using System.Collections.Generic;
using iac.helpers;
using iac.models;

namespace iac.rules
{
    public class Fill:Rule
    {

       public Fill()
        {
            setRuleType(ruleTypes.RulesTypes.fill);
        }
       public override List<Operation> getOperationSet(Node node)
       {
           List<Operation> operations = new List<Operation>();
               
            foreach (Pitcher pitcher in node.getPitchers())
            {
                if (pitcher.getCurrentVolume() < pitcher.getMaxVolume())
                {
                    Operation operation = new Operation(ruleTypes.RulesTypes.fill,
                        pitcher.getId(),
                        pitcher.getId()
                        );
                        operations.Add(operation);
                }
            }
            return operations;
        }

        public override Node applyRule(Node node, Operation operation)
        {
            return fill(node, operation);
        }



        Node fill(Node node, Operation operation)
        {   
            Pitcher pitcherAfterFill= new Pitcher(node.getPitcherById(operation.getOrigin()));
            pitcherAfterFill.setCurrentVolume(pitcherAfterFill.getMaxVolume());
            pitcherAfterFill.setIsFull(true);
            Node newNode = new Node();
            List<Pitcher> newNodePitchers = new List<Pitcher>();
            List_operators.copyFromToMaintainingState(node.getPitchers(), newNodePitchers);
            newNode.setFather(node);
            newNode.setPitchers(newNodePitchers);
            newNode.replacePitcherById(operation.getOrigin(),pitcherAfterFill);
            newNode.setOperation("Encher o jarro: "+node.getPitcherById(operation.getOrigin()).getName());
            return newNode;
        }


        
    }
}