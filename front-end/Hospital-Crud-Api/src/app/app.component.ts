import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Paciente } from '../models/paciente';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  title = 'Hospital-Crud-Api';
  http = inject(HttpClient);
  urlApi = 'https://localhost:7165'
  pacientes$?: Observable<Paciente[]>;

  ngOnInit(): void {
    this.obterPacientes();
  }

  //Obter Pacientes
  obterPacientes(){
    this.pacientes$ = this.http.get<Paciente[]>(`${this.urlApi}/pacientes`)
  }
}
