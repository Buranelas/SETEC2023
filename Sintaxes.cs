// Este é um comentário de uma linha
/* Este é um
comentário de 
múltiplas linhas */


// Variaveis
int x; // declaração
x = 10; // atribuição
int y = 20; // declaração e atribuição


// Constantes
const int x = 10;


// Tipos de Dados:
int x = 10;
double y = 20.5;
char z = 'A';
string s = "Hello, world";
bool b = true;


// Operadores
int x = 10 + 5; // adição
int y = 10 - 5; // subtração
int z = 10 * 5; // multiplicação
int a = 10 / 5; // divisão
int b = 10 % 3; // módulo


// if-else
if (x > y)
{
    // código
}
else
{
    // código
}

// switch
switch (x)
{
    case 1:
        // código
        break;
    case 2:
        // código
        break;
    default:
        // código
        break;
}


// for loop
for (int i = 0; i < 10; i++)
{
    // código
}


// while loop
while (x < 10)
{
    // código
    x++;
}


// do-while loop
do
{
    // código
    x++;
} while (x < 10);


// Funções
int Add(int x, int y)
{
    return x + y;
}

int result = Add(10, 5);


// Classes
class Car
{
    public string color;

    public void Drive()
    {
        // código
    }
}

Car myCar = new Car();
myCar.color = "red";
myCar.Drive();