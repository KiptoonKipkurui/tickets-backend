pipeline {
  agent any
  stages {
    stage('build') {
      steps {
        sh '''cd TIcketingSystem.API

dotnet restore

dotnet build --configuration Release'''
      }
    }

  }
}