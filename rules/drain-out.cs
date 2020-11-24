using System;
using System.Collections.Generic;
using iac.helpers;
using iac.models;

namespace iac.rules
{
    public class Drain_out:Rule
    {

        public  Drain_out()
        { 
            setRuleType(ruleTypes.RulesTypes.drainOut);
        }
        
        public override List<Operation> getOperationSet(Node node)
        {
            List<Operation> operations = new List<Operation>();
            
            foreach (Pitcher pitcher in node.getPitchers())
            {
                if (pitcher.getCurrentVolume() > 0)
                {
                    Operation operation = new Operation(ruleTypes.RulesTypes.drainOut,
                        pitcher.getId(),pitcher.getId()
                    );
                    operations.Add(operation);
                }
            }
            return operations;
        }

        Node drainOut(Node node,Operation operation)
        {
            Node newNode= new Node();
            List<Pitcher> newNodePitchers = new List<Pitcher>();
            Pitcher pitcherAfterDrainOut= new Pitcher(node.getPitcherById(operation.getOrigin()));
            pitcherAfterDrainOut.setCurrentVolume(0);
            pitcherAfterDrainOut.setIsFull(false);
            List_operators.copyFromToMaintainingState(node.getPitchers(), newNodePitchers);
            newNode.setPitchers(newNodePitchers);  
            newNode.replacePitcherById(operation.getOrigin(),pitcherAfterDrainOut);            
            newNode.setFather(node);
            newNode.setOperation("Esvaziar o jarro: "+node.getPitcherById(operation.getOrigin()).getName());
            return newNode;
        }
        
        public override Node applyRule(Node node, Operation operation)
        {
            return drainOut(node, operation);

        }
    }
}