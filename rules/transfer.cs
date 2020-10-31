using System;
using System.Collections.Generic;
using iac.helpers;
using iac.models;

namespace iac.rules
{
    public class Transfer : Rule
    {
        public override Node applyRule(Node node, Operation operation)
        {
            return transfer(node, operation);
        }

        public Transfer()
        {
            setRuleType(ruleTypes.RulesTypes.transfer);
        }

        Node transfer(Node node, Operation operation)
        {
            Node newNode = new Node();
            Pitcher destiny;
            Pitcher origin;
            string description;
            int ammount = 0;

            origin = new Pitcher(node.getPitcherById(operation.getOrigin()));
            destiny = new Pitcher(node.getPitcherById(operation.getDestiny()));
            
            if (origin.getCurrentVolume() >= destiny.getFreeSpace())
            {
                ammount = destiny.getFreeSpace();
            }
            else
            {
                ammount = origin.getCurrentVolume();
            }

            destiny.setCurrentVolume(destiny.getCurrentVolume() + ammount);
            origin.setCurrentVolume(origin.getCurrentVolume() - ammount);

            destiny.setIsFull(destiny.getMaxVolume() == destiny.getCurrentVolume());
            origin.setIsFull(origin.getMaxVolume() == origin.getCurrentVolume());

            List<Pitcher> newPitchers = new List<Pitcher>();
            List_operators.copyFromToMaintainingState(node.getPitchers(), newPitchers);
            newNode.setPitchers(newPitchers);
            newNode.replacePitcherById(operation.getOrigin(), origin);
            newNode.replacePitcherById(operation.getDestiny(), destiny);
            newNode.setFather(node);

            description =
                $"Transferir {ammount} do jarro {origin.getName()} para o para o jarro {destiny.getName()}";
            
            newNode.setOperation(description);
            return newNode;
        }

        public override List<Operation> getOperationSet(Node node)
        {
            List<Pitcher> pitchers = node.getPitchers();

            List<Operation> operations = new List<Operation>();


            foreach (var pitcher1 in pitchers)
            {
                foreach (var pitcher2 in pitchers)
                {
                    if (pitcher1.getId() != pitcher2.getId()) // não aplico transferência de um vaso para ele mesmo
                    {
                        if (
                            pitcher1.getCurrentVolume() > 0
                            &&
                            (pitcher2.getIsFull() == false))
                        {
                            Operation operation = new Operation(ruleTypes.RulesTypes.transfer,
                                pitcher1.getId(),
                                pitcher2.getId()
                            );
                            operations.Add(operation);
                        }

                        if (pitcher2.getCurrentVolume() > 0
                            &&
                            (pitcher1.getIsFull() == false))
                        {
                            Operation operation2 = new Operation(ruleTypes.RulesTypes.transfer,
                                pitcher2.getId(),
                                pitcher1.getId()
                            );
                            operations.Add(operation2);
                        }
                    }
                }
            }

            return operations;
        }
    }
}