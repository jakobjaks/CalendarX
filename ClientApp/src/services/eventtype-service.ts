import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IEventType} from "../interfaces/IEventType";

export var log = LogManager.getLogger('EventService');

@autoinject
export class EventTypeService extends BaseService<IEventType> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'EventType');
  }

}
