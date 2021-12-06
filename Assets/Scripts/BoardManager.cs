using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance=null;
	private void Awake() {
		if(instance==null){
			instance=this;
		}else if(instance!=this){
			Destroy(gameObject);
		}
        DontDestroyOnLoad(this);
	}
    public Board boardPrefab;
    private Board board;
    public List<List<int>> grid=new List<List<int>>();
    
    public void Init(){
        board=Instantiate(boardPrefab,Vector3.zero,Quaternion.identity);
        grid=board.grid;
        board.Sync(grid);
    }
    public void BoardPush(int isHorizontal,int isPlus){
        if(isHorizontal){
            for(int i=0;i<grid.Count();++i){
                if(isPlus){
                    int last=grid[i].Count()-1;
                    for(int j=grid[i].Count()-1;j>=0;--j){
                        if(grid[i][j]!=0){
                            if(j!=last){
                                grid[i][last]=grid[i][j];
                                grid[i][j]=0;
                                board.MoveBlock(i,j,i,last);
                            }
                            --last;
                        }
                    }
                }else{
                    int last=0;
                    for(int j=0;j<grid[i].Count();++j){
                        if(grid[i][j]!=0){
                            if(j!=last){
                                grid[i][last]=grid[i][j];
                                grid[i][j]=0;
                                board.MoveBlock(i,j,i,last);
                            }
                            ++last;
                        }
                    }
                }
            }
        }else{
            for(int i=0;i<grid[0].Count();++i){
                if(!isPlus){
                    int last=grid.Count()-1;
                    for(int j=grid.Count()-1;j>=0;--j){
                        if(grid[j][i]!=0){
                            if(j!=last){
                                grid[last][i]=grid[j][i];
                                grid[j][i]=0;
                                board.MoveBlock(j,i,last,i);
                            }
                            --last;
                        }
                    }
                }else{
                    int last=0;
                    for(int j=0;j<grid.Count();++j){
                        if(grid[j][i]!=0){
                            if(j!=last){
                                grid[last][i]=grid[j][i];
                                grid[j][i]=0;
                                board.MoveBlock(j,i,last,i);
                            }
                            ++last;
                        }
                    }
                }
            }
        }
        board.Sync(grid);
    }
    public void BoardPop(){
        //
        board.Sync(grid);
    }
    public void BoardRandomCreate(){
        int type=BoardRandomCreate.Range(0,board.blockTypes.Count);
        int x=Random.Range(0, grid.Count);
        int y=Random.Range(0, grid[0].Count);
        while(grid[x][y]!=0){
            x=Random.Range(0, grid.Count);
            y=Random.Range(0, grid[0].Count);
        }
        grid[x][y]=type;
        board.CreateBlock(x,y,type);
        board.Sync(grid);
    }
}
