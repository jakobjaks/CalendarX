import {IBaseEntity} from "./IBaseEntity";
import {IAdministrativeUnit} from "./IAdministrativeUnit";
import {ILocation} from "./ILocation";
import {IEventType} from "./IEventType";

export interface IEvent extends IBaseEntity {
  name: string;
  description: string;
  administrativeUnits: IAdministrativeUnit[];
  locations: ILocation[];
  eventTypes: IEventType[];
  fileName: string;


}
