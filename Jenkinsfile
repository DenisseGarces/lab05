pipeline{
  agent any
  enviroment{    
    APPNAME="lab01"
    IMAGE="Lab01"
    REGISTRY="DenisseGarces"
    DOCKER_HUB_LOGIN=credentials('dockerhub-DenisseGarces')    
  }
  stages {
    stage('Build Image'){
      steps{
        sh "pwd"
        sh 'docker build -t lab01:10 .'
      }
    }
  }
}
