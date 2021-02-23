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

    stage('error') {
      steps {
        dir(path: '/var/jenkins_home/workspace/tickets-backend_master/TIcketingSystem.API/bin/Release/netcoreapp3.1/') {
          sh 'zip release.zip *'
        }

      }
    }

  }
}