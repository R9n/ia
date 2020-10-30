using System;
using System.Collections.Generic;
using iac.models;

namespace iac.rules
{
    public class Transfer:Rule
    {
        public override Node applyRule(Node node, Operation operation)
         {
             return transfer(node,operation);
         }

       public  Transfer()
        {
            setRuleType(ruleTypes.RulesTypes.transfer);
        }

         Node transfer(Node node,Operation operation) {
             Node newNode = new Node();
             Pitcher destiny;
             Pitcher origin;
             string description;
             
             
             origin  = new Pitcher(node.getPitcherById(operation.getOrigin()));
             destiny = new Pitcher(node.getPitcherById(operation.getDestiny()));
             int originalOriginIndex = node.getPitcherIndexById(operation.getOrigin());
             int originalDestinyIndex = node.getPitcherIndexById(operation.getDestiny());
             
             description = 
                 $"Transferir {origin.getCurrentVolume()} do jarro {origin.getName()} para o para o jarro ${destiny.getName()}";
                
                destiny.setCurrentVolume(destiny.getCurrentVolume()+origin.getCurrentVolume());
                destiny.setIsFull(destiny.getMaxVolume() == destiny.getCurrentVolume());
                    ;
                origin.setIsFull(false); 
                origin.setCurrentVolume(0);
                
             List<Pitcher> newPitchers = new List<Pitcher>();
             if (originalOriginIndex < originalDestinyIndex)
             {
                 newPitchers.Add(origin);
                 newPitchers.Add(destiny);
             }else
             {
                 newPitchers.Add(destiny);
                 newPitchers.Add(origin);
             }
            newNode.setPitchers(newPitchers);
            newNode.setFather(node);
            newNode.setOperation(description);
            return newNode;
         }

         public override List<Operation> getOperationSet(Node node)
         {
             List<Pitcher> pitchers = node.getPitchers();

             List<Operation> operations = new List<Operation>();
             
             if ((pitchers[0].getCurrentVolume() <= pitchers[1].getFreeSpace()) &&
                 pitchers[0].getCurrentVolume() > 0)
             {
                 Operation operation = new Operation(ruleTypes.RulesTypes.transfer,
                     pitchers[0].getId(),
                     pitchers[1].getId()
                 );
                 operations.Add(operation);
             }
             if ((pitchers[1].getCurrentVolume() <= pitchers[0].getFreeSpace()) &&
                 pitchers[1].getCurrentVolume() > 0)
             {
                 Operation operation2 = new Operation(ruleTypes.RulesTypes.transfer,
                     pitchers[1].getId(),
                     pitchers[0].getId()
                 );
                 operations.Add(operation2);
             }

             return operations;
         }
    }
        
    }
