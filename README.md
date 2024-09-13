# usersApp.Api
 Aplicação de gerenciamento de usuários

Aplicação criada utilizando o .Net 8.0 e arquitetura em camadas.

A ConnectionString pode ser alterada em:

![image](https://github.com/user-attachments/assets/be87f3b7-d33a-4f69-b0ce-ca5dc7f8f2d1)

A politica de CORS pode ser alterada em:

![image](https://github.com/user-attachments/assets/a8277c04-11f9-4df3-98f6-771a7085f533)

Abaixo o script de criação do banco de dados necessário para que a aplicação funcione corretamente

> ```sql
> CREATE DATABASE userdb;
> GO
> 
> USE userdb;
> GO
> 
> CREATE TABLE tb_user (
>     full_name NVARCHAR(100) NOT NULL,
>     birth_date DATE NOT NULL,
>     income DECIMAL(18, 2) NOT NULL,
>     CPF CHAR(11) NOT NULL UNIQUE
> );
> GO
> ```

