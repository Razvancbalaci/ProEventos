import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];

  widthImg: number = 120;
  marginImg: number = 2;
  showImg: boolean = true;
  private _filterList: string = '';

  public get filterList() : string {
    return this._filterList;
  }

  public set filterList(value: string){
    this._filterList = value;
    this.eventosFiltrados = this.filterList ? this.filteredEventos(this.filterList) : this.eventos;
  }

  filteredEventos(filterBy: string) : any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  changeImg() {
    this.showImg = !this.showImg;
  }
  public getEventos(): void {
    this.http.get('https://localhost:5001/api/evento').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }
}
