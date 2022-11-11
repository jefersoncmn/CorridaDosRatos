using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsavel por ser o estado que irá gerar o mapa para simulação dos algoritmos de busca
/// </summary>
public class MapGeneratorController : MonoBehaviour
{

    public GameObject[] cellmap;

    public GameObject cellmodel;

    public GameObject map;

    private int mapCellsQuantityX = 25;
    private int mapCellsQuantityZ = 25;
    private float cellSizeX = 0.5f;
    private float cellSizeZ = 0.5f;


    void Awake(){
        map = GameObject.Find("Map");

        //Get cellModel size
        cellSizeX = cellmodel.transform.localScale.x;
        cellSizeZ = cellmodel.transform.localScale.z;

        int quantity = mapCellsQuantityX * mapCellsQuantityZ;
        cellmap = new GameObject[quantity];
    }

    Cell referenciaMatriz, auxiliarColuna, auxiliarLinha, ponteiroFixoA, ponteiroFixoB, ponteiroMovelA, ponteiroMovelB, referenciaAtual;

    /// <summary>
    /// Código responsável por instanciar os caminhos do mapa
    /// </summary>
    /// <param name="columns">Quantidade de colunas</param>
    /// <param name="lines">Quantidade de linhas</param>
    public void spawnPaths()
    {
        int columns = mapCellsQuantityX;
        int lines = mapCellsQuantityZ;

        int i = 0;

        for (int x = 0; x < columns; x++)
        {
            referenciaAtual = createCell(i, x, 0);
            i++;

            if (referenciaMatriz == null)
            {
                referenciaMatriz = referenciaAtual;
                auxiliarColuna = referenciaAtual;
                auxiliarLinha = referenciaAtual;
            }
            else
            {
                referenciaAtual.up = auxiliarColuna;
                auxiliarColuna.down = referenciaAtual;
                auxiliarColuna = referenciaAtual;
                auxiliarLinha = auxiliarColuna;
            }

            for (int z = 0; z < lines - 1; z++)
            {
                referenciaAtual = createCell(i, x, z + 1);
                i++;

                referenciaAtual.left = auxiliarLinha;
                auxiliarLinha.right = referenciaAtual;
                auxiliarLinha = referenciaAtual;

            }
        }

        ponteiroFixoA = referenciaMatriz;
        ponteiroFixoB = referenciaMatriz.down;
        ponteiroMovelA = ponteiroFixoA.right;
        ponteiroMovelB = ponteiroFixoB.right;

        for (int x = 0; x < columns - 1; x++)
        {

            for (int z = 0; z < lines - 1; z++)
            {

                ponteiroMovelA.down = ponteiroMovelB;
                ponteiroMovelB.up = ponteiroMovelA;

                ponteiroMovelA = ponteiroMovelA.right;
                ponteiroMovelB = ponteiroMovelB.right;
            }

            ponteiroFixoA = ponteiroFixoB;

            if (ponteiroFixoB.down != null)
                ponteiroFixoB = ponteiroFixoB.down;

            ponteiroMovelA = ponteiroFixoA.right;
            ponteiroMovelB = ponteiroFixoB.right;
        }

    }

    /// <summary>
    /// Função para criação de novas celulas
    /// </summary>
    /// <param name="index">variavel que indica qual a celula da matriz está sendo criada no momento</param>
    /// <param name="x">variavel da posição x</param>
    /// <param name="z">variavel da posição z</param>

    Cell createCell(int index, int x, int z)
    {

        cellmap[index] = Instantiate(cellmodel, new Vector3(x*cellSizeX, 0, z*cellSizeZ), Quaternion.identity);//intancia um bloco
        cellmap[index].transform.SetParent(map.transform, false);
        cellmap[index].gameObject.AddComponent(typeof(Cell));//Coloca a classe Cell no bloco
        Cell cell = cellmap[index].GetComponent(typeof(Cell)) as Cell;//Pega a classe Cell que foi colocada no bloco (feita na linha anterior)
        cell.cellObject = cellmap[index];//E dentro da classe Cell define o gameObject pra ele saber quem é o objeto dele
        
        // generalController.cellmap[index] = cellmap[index];//Armazena os objetos na classe GeneraController
        // defineTerrain(generalController.cellmap[index]);//Define o tipo de terreno
        defineTerrain(cellmap[index]);

        return cell;
    }


    /// <summary>
    /// Função para definir que tipo de terreno o bloco de caminho irá ser
    /// </summary>
    /// <param name="cell">O objeto do caminho</param>
    void defineTerrain(GameObject cellObject)
    {
        Cell cell = cellObject.GetComponent(typeof(Cell)) as Cell;

        float perlinResult = Mathf.PerlinNoise((float)cellObject.gameObject.transform.position.x / 6 * Random.Range(0, 10), (float)cellObject.gameObject.transform.position.z / 6 * Random.Range(0, 10));

        if (perlinResult < 0.2f)
        {
            cell.ambientType = AmbientType.Solido;
            var cubeRenderer = cellObject.GetComponent<Renderer>();
            cubeRenderer.material.color = Color.cyan;
        }
        else if (perlinResult >= 0.2f && perlinResult < 0.4f)
        {
            cell.ambientType = AmbientType.Plano;
            var cubeRenderer = cellObject.GetComponent<Renderer>();
            cubeRenderer.material.color = Color.green;
        }
        else if (perlinResult >= 0.4f && perlinResult < 0.6f)
        {
            cell.ambientType = AmbientType.Arenoso;
            var cubeRenderer = cellObject.GetComponent<Renderer>();
            cubeRenderer.material.color = Color.yellow;
        }
        else if (perlinResult >= 0.6f && perlinResult < 0.8f)
        {
            cell.ambientType = AmbientType.Rochoso;
            var cubeRenderer = cellObject.GetComponent<Renderer>();
            cubeRenderer.material.color = Color.grey;
        }
        else
        {
            cell.ambientType = AmbientType.Pantano;
            var cubeRenderer = cellObject.GetComponent<Renderer>();
            cubeRenderer.material.color = Color.black;
        }

    }

    /// <summary>
    /// Função que deletará a celula do mapa
    /// </summary>
    /// <param name="cell">Objeto da celula a ser deletada</param>
    void deleteCellInTheMap(GameObject cell)
    {
        Cell cellclass = cell.gameObject.GetComponent<Cell>() as Cell;

        Cell ponteiro;

        if (cellclass.right != null)
        {
            ponteiro = cellclass.right;
            ponteiro.left = null;
        }

        if (cellclass.left != null)
        {
            ponteiro = cellclass.left;
            ponteiro.right = null;
        }

        if (cellclass.up != null)
        {
            ponteiro = cellclass.up;
            ponteiro.down = null;
        }

        if (cellclass.down != null)
        {
            ponteiro = cellclass.down;
            ponteiro.up = null;
        }

        Destroy(cell);
    }
}
