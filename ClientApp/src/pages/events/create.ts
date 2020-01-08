import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IEvent} from "../../interfaces/IEvent";
import {EventService} from "../../services/events-service";
import {IAdministrativeUnit} from "../../interfaces/IAdministrativeUnit";
import {ILocation} from "../../interfaces/ILocation";
import {IEventType} from "../../interfaces/IEventType";
import {LocationService} from "../../services/locations-service";
import {AdministrativeUnitService} from "../../services/administrativeunit-service";
import {EventTypeService} from "../../services/eventtype-service";
import {IAreaOfInterest} from "../../interfaces/IAreaOfInterest";
import {IOrganization} from "../../interfaces/IOrganization";
import {IPerformer} from "../../interfaces/IPerformer";
import {ITargetAudience} from "../../interfaces/ITargetAudience";
import {AreaOfInterestService} from "../../services/areaofinterests-service";
import {OrganizationService} from "../../services/organization-service";
import {PerformerService} from "../../services/performers-service";
import {TargetAudienceService} from "../../services/targetaudiences-service";

export var log = LogManager.getLogger('Events.Create');

@autoinject
export class Create {
  
  private selectedFiles = [];
  
  private event: IEvent;
  private administrativeUnitList: IAdministrativeUnit[] = [];
  private locationList: ILocation[] = [];
  private eventTypeList: IEventType[] = [];
  private areaOfInterestsList: IAreaOfInterest[] = [];
  private organizationList: IOrganization[] = [];
  private performerList: IPerformer[] = [];
  private targetAudienceLists: ITargetAudience[] = [];
  private sponsorList: IOrganization[] = [];

  
  private administrativeUnitSelected: IAdministrativeUnit[] = [];
  private locationSelected: ILocation[] = [];
  private eventTypeSelected: IEventType[] = [];
  private areaOfInterestsSelected: IAreaOfInterest[] = [];
  private organizationSelected: IOrganization[] = [];
  private performerSelected: IPerformer[] = [];
  private targetAudienceSelected: ITargetAudience[] = [];
  private sponsorSelected: IOrganization[] = [];

  constructor(
    private router: Router,
    private eventService: EventService,
    private locationService: LocationService,
    private administrativeUnitService: AdministrativeUnitService,
    private eventTypeService: EventTypeService,
    private areaOfInterestService: AreaOfInterestService,
    private organizationService: OrganizationService,
    private performerService: PerformerService,
    private targetAudienceService: TargetAudienceService,
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('event', this.event);
    this.event.administrativeUnits = this.administrativeUnitSelected;
    this.event.locations = this.locationSelected;
    this.event.eventTypes = this.eventTypeSelected;
    var newName = this.makeid(20);
    var oldName = this.selectedFiles[0].name.split(".");
    oldName = oldName[oldName.length - 1];
    
    var blob = this.selectedFiles[0].slice(0, this.selectedFiles[0].size, this.selectedFiles[0].type);
  
    var newFile = new File([blob], newName + "." + oldName, {type: this.selectedFiles[0].type});

    this.event.fileName = newName;
    this.eventService.post(this.event!, newFile).then(
      response => {
        if (response.status == 201){
          console.log('response200')
          this.router.navigateToRoute("EventsIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
  }

  clearFiles() {
    document.getElementById("files").nodeValue = "";
  }
  
  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);
    this.administrativeUnitService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.administrativeUnitList = jsonData;
      }
    );

    this.locationService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.locationList = jsonData;
      }
    );

    this.eventTypeService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.eventTypeList = jsonData;
      }
    );
    this.targetAudienceService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.targetAudienceLists = jsonData;
      }
    );
    this.organizationService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.organizationList = jsonData;
      }
    );
    this.areaOfInterestService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.areaOfInterestsList = jsonData;
      }
    );
    this.performerService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.performerList = jsonData;
      }
    );
    
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
  //AdministrativeUnit
  adminUnitCount = [0];
  addAdminOption() {
    this.adminUnitCount.push(this.adminUnitCount.length);
  }
  removeAdminOption() {
    if (this.adminUnitCount.length > 1) {
      this.adminUnitCount.pop();
      this.administrativeUnitSelected.pop()
    }
  }
  //Location
  locationUnitCount = [0]
  addLocationOption() {
    this.locationUnitCount.push(this.locationUnitCount.length)
  }
  removeLocationOption() {
    if (this.locationUnitCount.length > 1) {
      this.locationUnitCount.pop();
      this.locationSelected.pop()
    }
  }
  //EventTypes
  eventTypesUnitCount = [0]
  addEventTypesOption() {
    this.eventTypesUnitCount.push(this.eventTypesUnitCount.length)
  }
  removeEventTypesOption() {
    if (this.eventTypesUnitCount.length > 1) {
      this.eventTypesUnitCount.pop();
      this.eventTypeSelected.pop()
    }
  }
  //Organization
  organizationUnitCount = [0]
  addOrgOption() {
    this.organizationUnitCount.push(this.organizationUnitCount.length)
  }
  removeOrgOption() {
    if (this.organizationUnitCount.length > 1) {
      this.organizationUnitCount.pop();
      this.organizationSelected.pop()
    }
  }
  //Sponsors
  sponsorUnitCount = [0]
  addSponsOption() {
    this.sponsorUnitCount.push(this.sponsorUnitCount.length)
  }
  removeSponsOption() {
    if (this.sponsorUnitCount.length > 1) {
      this.sponsorUnitCount.pop();
      this.sponsorSelected.pop()
    }
  }
  //Performers
  performerUnitCount = [0]
  addPerfOption() {
    this.performerUnitCount.push(this.performerUnitCount.length)
  }
  removePerfOption() {
    if (this.performerUnitCount.length > 1) {
      this.performerUnitCount.pop();
      this.performerSelected.pop()
    }
  }
  //TargetAudience
  targetAudienceUnitCount = [0]
  addTargOption() {
    this.targetAudienceUnitCount.push(this.targetAudienceUnitCount.length)
  }
  removeTargOption() {
    if (this.targetAudienceUnitCount.length > 1) {
      this.targetAudienceUnitCount.pop();
      this.targetAudienceSelected.pop()
    }
  }

  makeid(length) {
    var result           = '';
    var characters       = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for ( var i = 0; i < length; i++ ) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }
  
}
