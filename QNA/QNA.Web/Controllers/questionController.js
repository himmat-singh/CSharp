(function(){
    'use strict';
    
    var app = angular.module('app');
    
    app.controller('QuestionController',function($scope,toaster,qnaService,$stateParams){
        $scope.questions = [];
        $scope.question = {};
        $scope.question.QOptions = [];
        $scope.question.QType="0";
        var promise;
        var id = parseInt($stateParams.id);        
        
        if(id>0){
            promise = qnaService.getQuestion(id);
            promise.then(function(data){
                $scope.question = data;
                $scope.question.QType = String($scope.question.QType);
            });
        }
        else{        
            promise = qnaService.getQuestion(0);
            promise.then(function(data){
                $scope.questions = data;
            });
        }
        
        $scope.GetLimitArr = function(n){             
            var limit = [];
            for(var i=1;i<=n;i++)
                limit.push(i);
            return limit;
        };
        
        $scope.OnDisplayLimitChange = function(){
          var n = $scope.question.MultiChoiceAnswerDisplayLimit;
            /*console.log("Display Limit: "+n+" | Options: "+ $scope.question.QOptions.length);*/
            
            if(n > $scope.question.QOptions.length){
                for(var i = $scope.question.QOptions.length;i<n;i++)
                    $scope.question.QOptions.push(qnaService.CreateQuestionOption($scope.question.QuestionId));
            }
            else{
                for(var i = $scope.question.QOptions.length;i>n;i--)
                $scope.question.QOptions.pop();
            }
        };
        
        $scope.OnQTypeChange = function(){
          if(parseInt($scope.question.QType) === 2 )  {
              $scope.question.QOptions = [];
              $scope.question.MultiChoiceAnswerDisplayLimit = 0;
          }
        };
        
        $scope.SaveQuestion = function(){  
            $scope.question.QuestionId = 0;
            $scope.question.VisitCount =0;
            promise = qnaService.saveQuestion($scope.question);
            promise.then(function(){
                toaster.pop('success', "Question - "+$scope.question.QuestionDetail, "Question has been saved successfully!");
            },function(){
                toaster.pop('error', "Question - "+$scope.question.QuestionDetail, "Question has not been saved. Please try again!");
            });            
        };
        
        $scope.UpdateQuestion = function(){ 
            $scope.question.QOptions
            promise = qnaService.updateQuestion($scope.question);
            promise.then(function(){
                toaster.pop('success', "Question - "+$scope.question.QuestionDetail, "Question has been updated successfully!");
            },function(){
                toaster.pop('error', "Question - "+$scope.question.QuestionDetail, "Question has not been updated. Please try again!");
            });
        };
        
        $scope.CanelQuestion = function(){            
            toaster.pop('error', "Question", "Question details has been reset successfully!");
        };
        
    });
    
    
}());