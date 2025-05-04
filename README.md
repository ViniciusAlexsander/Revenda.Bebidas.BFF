# Revenda.Bebidas.BFF

Este projeto utiliza **PostgreSQL** como banco de dados principal. Por isso, é necessário configurar adequadamente a string de conexão e executar os scripts de estrutura inicial do banco antes de iniciar a aplicação.

## 🔧 Configuração do Banco de Dados

1. **Configure a Connection String**

   No arquivo de configuração da aplicação (por exemplo, `appsettings.Development.json`), defina a string de conexão com suas credenciais do PostgreSQL:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=revenda_bebidas;Username=seu_usuario;Password=sua_senha"
   }
   ```

2. **Crie o banco e execute os scripts**

   Antes de rodar o projeto, é necessário criar a estrutura do banco de dados.

   Execute os scripts SQL disponíveis na pasta:

   ```
   Revenda.Bebidas.BFF.Infra.DbAdapter/Scripts/
   ```

   Os scripts criam as tabelas, extensões necessárias (`uuid-ossp`), e relações entre as entidades (revendas, pedidos, itens, etc.).

   Você pode executá-los utilizando um cliente SQL, como:

   * **psql** (terminal)
   * **DBeaver**
   * **TablePlus**
   * **PgAdmin**

## Considerações
- Sobre a minha implementação:
    - Decidi por usar a arquitetura hexagonal, que é algo uma arquitetura que trabalhei por um tempo.
    - Optei por usar um background service para organizar a fila em casos de falha, tentei a implementação utilizando serviceBus porem me deparei com problemas de compatibilidade na hora de rodar localmente, por não ter muito sobrando, fiz a troca para usar o background service pois é algo que já implementei no passado.
    - Não fiquei muito satisfeito com a implementação, ficou faltando algumas coisas para chegar em resultado que eu considere bom, o tempo não foi suficiente para fazer um melhor tratamento dos dados de entrada, não consegui ter tempo de implementar os testes, poderia adicionar uma forma de autenticação, foquei apenas em entregar o suficiente para que a aplicação fizesse o que foi pedido.
