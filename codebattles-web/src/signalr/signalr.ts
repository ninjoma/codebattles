import { HubConnectionBuilder, HubConnection } from "@microsoft/signalr";

let connection: HubConnection | null = null;

export function startSignalRConnection(): Promise<HubConnection> {
  const connection = new HubConnectionBuilder()
    .withUrl("https://localhost:7297/hubs/codehub")
    .build();

  return connection.start()
    .then(() => {
      console.log("---------------------------------------------\n Succesfully Connected to websocket CodeHub! \n---------------------------------------------");
      return connection;
    })
    .catch(error => {
      console.error("Error al establecer la conexión SignalR:", error);
      throw new Error("---------------------------------------------\n Couldn't Connect to websocket CodeHub! \n---------------------------------------------");
    })
    .finally(() => {
      // Lógica adicional que se ejecuta después de la resolución o el rechazo de la promesa
      // Puede ser un retorno o una llamada a otra función
      // Por ejemplo, puedes devolver un valor predeterminado o realizar alguna limpieza
    });
}