export interface Driver {
  id: string;
  name: string;
  surname: string;
  email: string;
  vehicleId: string;
}

export interface Vehicle {
  id: string;
  vehicleType: VehicleType;
  drivers: Driver[];
}

export enum VehicleType {
  Taxi,
  Bus,
  Train,
}
