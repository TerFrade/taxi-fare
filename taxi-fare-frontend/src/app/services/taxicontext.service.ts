import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";

import { Observable } from "rxjs";

import { Taxi } from "./types.services";

const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json",
    Authorization: "my-auth-token",
  }),
};

@Injectable()
export class TaxiContextService {
  API_URL = "https://localhost:44381/Taxi";

  constructor(private http: HttpClient) {}

  getTaxi(): Observable<Taxi[]> {
    return this.http.get<Taxi[]>(this.API_URL);
  }

  getTaxiById(id: string): Observable<Taxi> {
    return this.http.get<Taxi>(this.API_URL + `/${id}`);
  }

  addTaxi(taxi: Taxi): Observable<Taxi> {
    return this.http.post<Taxi>(this.API_URL, taxi, httpOptions);
  }

  deleteTaxi(id: string): Observable<unknown> {
    const url = `${this.API_URL}/${id}`;
    return this.http.delete(url);
  }

  updateTaxi(taxi: Taxi): Observable<Taxi> {
    return this.http.put<Taxi>(this.API_URL + `/${taxi.id}`, taxi);
  }
}
