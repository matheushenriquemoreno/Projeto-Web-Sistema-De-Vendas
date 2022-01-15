



<h2>
O objetivo do Projeto foi o Desenvolver uma aplicação simples Utilizando o framework ASP .NET Core com o padrão de arquitetura/projeto MVC, para persistência dos dados foi utilizado o Entity framework, o banco de dados utilizado em questão foi MySQL.
</h2>

<h2>Contextualizando o padrão de Projeto MVC:</h2> 
<hr>
<h3>
O MVC e um padrão de arquitetura que divide uma aplicação web em três Camadas essas são Model (Modelo) View (Visão/Tela) e Controller (Controle). Esse padrão traz como beneficio um isolamento das regras de negócio da interface do usuário. Permitindo assim várias interfaces de usuário podendo ser modificadas sem afetar a regra do negócio em si. Além desse padrão ser utilizado em vários tipos de projetos como Desktop, Web e Mobile.
</h3>
<hr>

<h3>
Controller: Receber todas as requisições da view e faz seu processamento utilizando do protocolo HTTP, e as classes que implementamos para retornar ou tratar os dados recebidos. 
</h3>
<hr>

<h3>
View:  E a camada onde acontece a interação com o usuário, onde acontece a exibição de dados através de HTML, XML ou Json como em algumas APIS, As views dentro do .NET podem ser dos seguintes tipos: View, Partial view, e templates, onde todas se completam pra fazer uma tela.
</h3> 
<hr>

<h3>
Model: E onde fica as entidades do negócio, fazendo a conexão com o banco de dados e as regras de negócio.
</h3>

<h2>Essa imagem ilustra o que acontece nesse padrão:</h2>

![image](https://user-images.githubusercontent.com/69221000/149632903-20ee22ba-a4a6-47d6-9e87-5bef8be9c981.png)


<h2>Video mostrando a funcionalidade do sistema: <h3/>

https://user-images.githubusercontent.com/69221000/149634041-4d6e1817-ada6-42b1-9580-7058eca24665.mp4


<h2>Modelagem do banco de dados da aplicação</h2>

![DiagramaMEr](https://user-images.githubusercontent.com/69221000/149631903-92989681-424a-4c4c-ad43-2c751747af4f.png)
