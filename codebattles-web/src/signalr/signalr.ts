import { HubConnectionBuilder, HubConnection } from "@microsoft/signalr";

let connection: HubConnection | null = null;

export function startSignalRConnection(): Promise<HubConnection> {
  const connection = new HubConnectionBuilder()
    .withUrl("https://jolly-wave-016057810.3.azurestaticapps.net/hubs/codehub")
    .build();

  return connection.start()
    .then(() => {
      console.log("Succesfully Connected to websocket CodeHub!");
      return connection;
    })
    .catch(error => {
      console.error("Error al establecer la conexión SignalR:", error);
      throw new Error("Couldn't Connect to websocket CodeHub!");
    })
    .finally(() => {
      // Lógica adicional que se ejecuta después de la resolución o el rechazo de la promesa
      // Puede ser un retorno o una llamada a otra función
      // Por ejemplo, puedes devolver un valor predeterminado o realizar alguna limpieza
    });
}