import { Rota } from "./rota.model";

export interface Viagem {
  id: number;
  rotas: Rota[];
  valorTotal: number;
}
