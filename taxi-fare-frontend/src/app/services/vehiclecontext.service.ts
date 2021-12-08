import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { Observable } from "rxjs";

import { Vehicle } from "./types.services";
@Injectable()
export class VehicleContextService {
  API_URL = "https://localhost:44381/Vehicle";

  constructor(private http: HttpClient) {}

  getVehicles(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(this.API_URL);
  }

  getVehicleById(id: string): Observable<Vehicle> {
    return this.http.get<Vehicle>(this.API_URL + `/${id}`);
  }

  addVehicle(vehicle: Vehicle): Observable<Vehicle> {
    return this.http.post<Vehicle>(this.API_URL, vehicle);
  }

  deleteVehicle(id: string): Observable<unknown> {
    const url = `${this.API_URL}/${id}`;
    return this.http.delete(url);
  }

  updateVehicle(vehicle: Vehicle): Observable<Vehicle> {
    return this.http.put<Vehicle>(this.API_URL + `/${vehicle.id}`, vehicle);
  }
}
