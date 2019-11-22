import {IBaseEntity} from "./IBaseEntity";

export interface IOrganization extends IBaseEntity {
  name: string;
  description: string;
}
