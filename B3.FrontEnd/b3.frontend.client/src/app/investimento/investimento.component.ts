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
    valorLiquido: 0,
    erroAoCalcular: '',
  };

  erroAoCalcular: string | undefined;

  calcularInvestimento(): void {

    this.resultadoInvestimento.erroAoCalcular = "";

    this.calculoService.efetuarCalculo(this.investimento).subscribe({
      next: resultado => {
        this.resultadoInvestimento = resultado;
      },
      error: erro => {
        this.resultadoInvestimento.valorBruto = 0;
        this.resultadoInvestimento.valorLiquido = 0;
        this.erroAoCalcular = erro.error;
      }
    });
  }

}
