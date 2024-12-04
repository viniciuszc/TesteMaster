import { Localizacao } from "./localizacao.model";

export interface Rota {
  id: number;
  origem: Localizacao;
  destino: Localizacao;
  valor: number;
}
  
