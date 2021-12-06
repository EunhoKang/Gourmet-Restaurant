using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct SubArray{
    public Transform[] pos;
}

public class Board : MonoBehaviour
{
    public int gridSize=5;
    public SubArray[] PosArray;
    private List<List<Block>> Blocks=new List<List<Block>>();
    public List<List<int>> grid=new List<List<int>>();
    public List<Block> blockTypes=new List<Block>();
    public Block NullBlock;

    private void Start()
    {
        for(int i=0;i<gridSize;++i){
            grid.Add(new List<int>());
            for(int j=0;j<gridSize;++j){
                grid[i].Add(0);
            }
        }
        for(int i=0;i<gridSize;++i){
            Blocks.Add(new List<Block>());
            for(int j=0;j<gridSize;++j){
                Block temp=Instantiate(NullBlock);
                Blocks[i].Add(temp);
            }
        }
    }
    public void MoveBlock(int x, int y, int X, int Y){
        //
    }

    public void CreateBlock(int x, int y, int type){
        Block temp=Instantiate(blockTypes[type],PosArray[x][y].position,Quaternion.identity);
        Blocks[x][y]=temp;
    }
    public void PopBlock(int x, int y){
        //
    }

    public void Sync(List<List<int>> gr){
        grid=gr;
    }
}
