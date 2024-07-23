import { Component } from '@angular/core';
import { Investimento } from '../investimento.model';
import { InvestimentoService } from './services/investimento.service';
import { InvestimentoResultado } from '../investimentoresultado';

@Component({
  selector: 'app-investimento',
  templateUrl: './investimento.component.html'
})
export class InvestimentoComponent {

  constructor(private readonly calculoService: InvestimentoService) {
  }

  public investimento: Investimento = {
    valor: 0,
    prazoMeses: 0,
  };

  public resultadoInvestimento: InvestimentoResultado = {
    valorBruto: 0,
    valorLiquido: 0
  };

  calcularInvestimento(): void {

    console.log(this.investimento);
    this.calculoService.efetuarCalculo(this.investimento)
      .subscribe(resultado => {
        this.resultadoInvestimento = resultado;
        console.log(this.resultadoInvestimento);
      });
  }

}
