import {IBaseEntity} from "./IBaseEntity";
import {IAdministrativeUnit} from "./IAdministrativeUnit";
import {ILocation} from "./ILocation";

export interface IEvent extends IBaseEntity {
  name: string;
  description: string;
  administrativeUnits: IAdministrativeUnit[];
  locations: ILocation[];
  
}
