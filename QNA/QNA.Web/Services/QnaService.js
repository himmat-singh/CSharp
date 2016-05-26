(function(){
    'use strict';
    
    var app = angular.module('app');
    
    app.service('qnaService',function($http, $q){
        var defer = $q.defer();
        
        this.getQuestion = function(id){            
            var url = 'http://localhost/QNA.WebService/api/qna/question/';
            if(parseInt(id)>0) url= url +id;
            console.log('Service input id : '+id);
            console.log('Service get url: '+ url);
         
            $http.get(url).then(function(res){
                defer.resolve(res.data);                
            }, function(err){
                defer.reject(err);
            });
            return defer.promise;
        };
          
        this.saveQuestion = function(question){
            console.log('save question: '+ question.QuestionDetail);
            var url = 'http://localhost/QNA.WebService/api/qna/question/add';
            $http.post(url,JSON.stringify(question))
                .then(function(res){
              defer.resolve(res.data);
          },function(err){
              defer.reject(err);
          });
            return defer.promise;
        };
        
        this.updateQuestion = function(question){
          console.log('Update question : '+ question.QuestionDetail);  
            var url = 'http://localhost/QNA.WebService/api/qna/question/edit/'+question.QuestionId;
            console.log(url);
            $http.put(url,JSON.stringify(question))
            .then(function(res){
                defer.resolve(res.data);
            },function(err){
                defer.reject(err);
            });
            return defer.promise;
        };
        
        
        this.CreateQuestionOption = function(id){
          return {
              OptionId: 0,
              QuestionId:id,
              OptionDetail:''
          }  
        };
        
    });
}());