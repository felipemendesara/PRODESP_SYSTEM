(function () {
    //Cria um Module 
    // será usado ['ng-Route'] quando implementarmos o roteamento
    var app = angular.module('AngularProdespApp', ['ngRoute']);  
    //Cria um Controller
    // aqui $scope é usado para compartilhar dados entre a view e o controller
    app.controller('AlunosController', function ($scope) { 
        $scope.Mensagem = "Não existe nenhum aluno cadastrado";
    });
})();