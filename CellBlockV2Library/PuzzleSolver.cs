using CellBlockV2Library.Instance_Stack_Editing;
using CellBlockV2Library.Possible_Block_Editing;
using CellBlockV2Library.Puzzle_Objects;
using CellBlockV2Library.Static_Methods;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellBlockV2Library
{
    public class PuzzleSolver
    {
        private ISolutionTracker _solutionTracker;
        private IPossibleOwnerEditor _possibleOwnerEditor;
        private IOwnershipSetter _ownershipSetter;
        private ICloneData _cloneData;
        private IRemoveInstances _removeInstances;


        public void GetSolution()
        {
            bool provesNoPossibleSolution = false;
            //Removes all PossibleBlocks containing a PredefinedCell belonging to a different MainBlock.
            foreach (IMainBlock mainBlock in _solutionTracker.Grid.MainBlocks)
            {
                if (_ownershipSetter.MarkCellAsOwned(mainBlock.PreDefinedCell, mainBlock))
                    provesNoPossibleSolution = true;
            }
            if (provesNoPossibleSolution == false)
            {
                SolveCurrentInstances();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void SolveCurrentInstances()
        {

            bool provesNoPossibleSolution = false;
            while (_ownershipSetter.ChangeHasOccured == true)
            {
                if(_possibleOwnerEditor.CheckAllCells())
                {
                    provesNoPossibleSolution = true;
                    break;
                }
            }

            if (_solutionTracker.Grid.HasSolution)
            {
                SaveSolution();
            }
            else if (provesNoPossibleSolution == false)
            {
                CopyandSet();
            }

            _removeInstances.RemoveTopInstances();
        }

        private void CopyandSet()
        {
            IMainBlock mainBlock = AdditionalMethods.GetMainBlockWithFewestPossibleBlock(_solutionTracker.Grid.MainBlocks);
            foreach (int possibleBlock in mainBlock.PossibleBlocks)
            {
                _cloneData.CloneInstancesAndData();
                _ownershipSetter.SetPossibleBlockAsSolution(AdditionalMethods.CreatePossibleBlockFromIndex(mainBlock, _solutionTracker.BlockDimensionSets, possibleBlock));
                SolveCurrentInstances();
            }
        }

        private void SaveSolution()
        {
            List<int> Solution = new List<int>();
            foreach (IMainBlock mainBlock in _solutionTracker.Grid.MainBlocks)
            {
                Solution.Add(mainBlock.Solution);
            }
            _solutionTracker.Solutions.Add(Solution);
        }


    }
}
