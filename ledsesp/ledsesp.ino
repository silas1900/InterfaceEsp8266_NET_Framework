//==================================================================================================================================================
/* Simples método para ligar e desligar utilizando Esp8266 NodeMCU e Aplicação Windows Form .NET Framework
 * 
 *  
 */
//===================================================================================================================================================
#include <ESP8266WiFi.h>

//===== DIRETIVAS ===========================================================================================================================================
#define led1 5 // d1  do NodeMCU
#define led2 14 // d0 do NodeMCU
#define led3 4 // d2  do NodeMCU

//=====================================================================================================================================================
// Nome do sua rede wifi
const char* ssid = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; 

// Senha do seu wifi
const char* password = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; 

//===============================================================================================================================================================
// Porta de comunicacao (normalmente se utiliza a 80 ou 8080)
WiFiServer server(80); 

//==========================================================================================================================================================
void setup() {
  
  Serial.begin(115200); 
  delay(10);
  
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(led3, OUTPUT);
   
  digitalWrite(led1, 0); 
  digitalWrite(led2, 0);
  digitalWrite(led3, 0);  

   // Mostra no monitor serial informacoes de conexao da rede
  Serial.println();
  Serial.println();
  Serial.print("conectando em ");
  Serial.println(ssid);
  
  // Inicializando a conexao
  WiFi.begin(ssid, password); 
  
  /* Enquanto nao conseguir conectar
    imprime um ponto na tela (dá a ideia de que esta carregando) */
  
  while (WiFi.status() != WL_CONNECTED) { 
    delay(500);
    Serial.print("."); 
  }

  Serial.println("");
  Serial.println("WiFi connectado");

  // Inicializa o servidor (o proprio esp8266)
  server.begin();
  Serial.println("Servidor inicializado");
  
  // Mostra o IP do servidor
  Serial.println(WiFi.localIP()); // Copie o endereço ip e adicione na variável set_status do javascript
}
//===========================================================================================================================================================
void loop() {
  
  // Guarda o status do servidor
  WiFiClient client = server.available(); 
  if ( ! client) {
    return;
  }
  
  // Quando estiver alguem acessando 
  Serial.println("novo cliente"); 
  
  // Enquanto nao tiver cliente
  while ( ! client.available()) { 
    delay(1);
  }
  
  // Lê caracteres do buffer serial
  String req = client.readStringUntil('\r');
  Serial.println(req);
  client.flush();
  
  // Verifica se existe a substring led5_on
  if (req.indexOf("led1_on") != -1) { //Liga led1
    digitalWrite(led1, 1);
    Serial.println(req.indexOf("led1_on"));
    
  } else if (req.indexOf("led1_off") != -1) {  // Verifica se existe a substring led1_off
    digitalWrite(led1, 0);                    //Desliga led1
    Serial.println(req.indexOf("led1_off"));
  } else if (req.indexOf("led2_on") != -1){ // Verifica se existe a substring led2_on
    digitalWrite(led2, 1);
    Serial.println(req.indexOf("led2_on"));
  } else if (req.indexOf("led2_off") != -1){
    digitalWrite(led2, 0);
    Serial.println(req.indexOf("led2_off"));
  } else if (req.indexOf("led3_on") != -1){  // Verifica se existe a substring led3_on
     digitalWrite(led3, 1);
     Serial.println(req.indexOf("led3_on"));
  } else if (req.indexOf("led3_off") != -1){
    digitalWrite(led3, 0);
    Serial.println(req.indexOf("led3_off"));
  }else if(req.indexOf("leds_off") != -1){
    digitalWrite(led1, 0); // Apaga tudo caso ligados
    digitalWrite(led2, 0);
    digitalWrite(led3, 0);
  }

  Serial.println("Cliente desconectado");
}
//==== END ===============================================================================================================================================
