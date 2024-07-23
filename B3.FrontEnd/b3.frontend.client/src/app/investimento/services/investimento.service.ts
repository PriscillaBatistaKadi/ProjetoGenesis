import { HttpClient } from "@angular/common/http";
import { Investimento } from "../../investimento.model";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { InvestimentoResultado } from "../../investimentoresultado";

@Injectable({

  providedIn:"root"

})

export class InvestimentoService {

  constructor(private http: HttpClient) { }

  efetuarCalculo(request: Investimento): Observable<InvestimentoResultado> {
    return this.http.get<InvestimentoResultado>(`https://localhost:7069/api/calculo-cdb?valorInicial=${request.valor}&meses=${request.prazoMeses}`);
  }

}
