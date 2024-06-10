import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Paciente } from '../models/paciente';
import { Observable } from 'rxjs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, MatToolbarModule, MatTableModule, MatInputModule, MatButtonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  constructor() {
    this.tabela = new MatTableDataSource<Paciente>([]);
  }
  title = 'Hospital-Crud-Api';
  http = inject(HttpClient);
  urlApi = 'https://localhost:7165'
  pacientes$?: Observable<Paciente[]>;
  tabela: MatTableDataSource<Paciente>;
  displayedColumns = ['nome', 'dataNascimento', 'genero', 'endereco', 'telefone', 'email'];

  ngOnInit(): void {
    this.obterPacientes();
  }

  //Obter Pacientes
  obterPacientes(): void {
    this.pacientes$ = this.http.get<Paciente[]>(`${this.urlApi}/pacientes`);
    this.pacientes$.subscribe(pacientes => {
      this.tabela = new MatTableDataSource<Paciente>(pacientes);
    });
  }




}
