import { Component, OnInit } from '@angular/core';
import { LocalizacaoService } from '../services/localizacao.service';
import { ViagemService } from '../services/viagem.service';
import { Localizacao } from '../models/localizacao.model';
import { Viagem } from '../models/viagem.model';

@Component({
  selector: 'app-viagem',
  templateUrl: './viagem.component.html',
  styleUrls: ['./viagem.component.css'],
  standalone: false
})
export class ViagemComponent implements OnInit {
  localizacoes: Localizacao[] = [];
  viagens: Viagem[] = [];
  origem!: string;
  destino!: string;

  constructor(
    private localizacaoService: LocalizacaoService,
    private viagemService: ViagemService
  ) { }

  ngOnInit(): void {
    this.localizacaoService.getAll().subscribe((data: Localizacao[]) => {
      this.localizacoes = data;
    });
  }

  selecionarMelhorRota(): void {
    if (this.origem && this.destino) {
      this.viagemService.listarViagensPossiveis(this.origem, this.destino).subscribe((data: Viagem[]) => {
        this.viagens = data;
      });
    }
  }

  salvarViagem(viagem: Viagem) {
    this.viagemService.add(viagem).subscribe(response => {
      console.log('Viagem salva com sucesso', response);
    }, error => {
      console.error('Erro ao salvar a viagem', error);
    });
  }
}