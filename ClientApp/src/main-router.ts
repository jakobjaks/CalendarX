import {PLATFORM, autoinject, LogManager} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import { AppConfig } from "app-config";

export var log = LogManager.getLogger('MainRouter');

@autoinject
export class MainRouter {
  
  public router: Router;

  constructor(private appConfig: AppConfig){
    log.debug('constructor');
  }


  configureRouter(config: RouterConfiguration, router: Router):void {
    log.debug('configureRouter');

    this.router = router;
    config.title = "Contact App - Aurelia";
    config.map(
      [
        {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'},

        {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
        {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
        {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},

        //{route: '', name: '', moduleId: PLATFORM.moduleName('pages/'), nav: true, title: ''},
        {route: ['AdministrativeUnits','AdministrativeUnits/index'], name: 'AdministrativeUnits' + 'Index', moduleId: PLATFORM.moduleName('pages/administrativeUnits/index'), nav: true, title: 'AdministrativeUnits'},
        {route: 'AdministrativeUnits/create', name: 'AdministrativeUnits' + 'Create', moduleId: PLATFORM.moduleName('pages/administrativeUnits/create'), nav: false, title: 'AdministrativeUnits Create'},
        {route: 'AdministrativeUnits/edit/:id', name: 'AdministrativeUnits' + 'Edit', moduleId: PLATFORM.moduleName('pages/administrativeUnits/edit'), nav: false, title: 'AdministrativeUnits Edit'},
        {route: 'AdministrativeUnits/delete/:id', name: 'AdministrativeUnits' + 'Delete', moduleId: PLATFORM.moduleName('pages/administrativeUnits/delete'), nav: false, title: 'AdministrativeUnits Delete'},
        {route: 'AdministrativeUnits/details/:id', name: 'AdministrativeUnits' + 'Details', moduleId: PLATFORM.moduleName('pages/administrativeUnits/details'), nav: false, title: 'AdministrativeUnits Details'},

        {route: ['AdministrativeUnitInEvents','AdministrativeUnitInEvents/index'], name: 'AdministrativeUnitInEvents' + 'Index', moduleId: PLATFORM.moduleName('pages/administrativeUnitInEvents/index'), nav: true, title: 'AdministrativeUnitInEvents'},
        {route: 'AdministrativeUnitInEvents/create', name: 'AdministrativeUnitInEvents' + 'Create', moduleId: PLATFORM.moduleName('pages/administrativeUnitInEvents/create'), nav: false, title: 'AdministrativeUnitInEvents Create'},
        {route: 'AdministrativeUnitInEvents/edit/:id', name: 'AdministrativeUnitInEvents' + 'Edit', moduleId: PLATFORM.moduleName('pages/administrativeUnitInEvents/edit'), nav: false, title: 'AdministrativeUnitInEvents Edit'},
        {route: 'AdministrativeUnitInEvents/delete/:id', name: 'AdministrativeUnitInEvents' + 'Delete', moduleId: PLATFORM.moduleName('pages/administrativeUnitInEvents/delete'), nav: false, title: 'AdministrativeUnitInEvents Delete'},
        {route: 'AdministrativeUnitInEvents/details/:id', name: 'AdministrativeUnitInEvents' + 'Details', moduleId: PLATFORM.moduleName('pages/administrativeUnitInEvents/details'), nav: false, title: 'AdministrativeUnitInEvents Details'},

        {route: ['AreaOfInterests','AreaOfInterests/index'], name: 'AreaOfInterests' + 'Index', moduleId: PLATFORM.moduleName('pages/areaOfInterests/index'), nav: true, title: 'AreaOfInterests'},
        {route: 'AreaOfInterests/create', name: 'AreaOfInterests' + 'Create', moduleId: PLATFORM.moduleName('pages/areaOfInterests/create'), nav: false, title: 'AreaOfInterests Create'},
        {route: 'AreaOfInterests/edit/:id', name: 'AreaOfInterests' + 'Edit', moduleId: PLATFORM.moduleName('pages/areaOfInterests/edit'), nav: false, title: 'AreaOfInterests Edit'},
        {route: 'AreaOfInterests/delete/:id', name: 'AreaOfInterests' + 'Delete', moduleId: PLATFORM.moduleName('pages/areaOfInterests/delete'), nav: false, title: 'AreaOfInterests Delete'},
        {route: 'AreaOfInterests/details/:id', name: 'AreaOfInterests' + 'Details', moduleId: PLATFORM.moduleName('pages/areaOfInterests/details'), nav: false, title: 'AreaOfInterests Details'},

        {route: ['EventInAreaOfInterests','EventInAreaOfInterests/index'], name: 'EventInAreaOfInterests' + 'Index', moduleId: PLATFORM.moduleName('pages/eventInAreaOfInterests/index'), nav: true, title: 'EventInAreaOfInterests'},
        {route: 'EventInAreaOfInterests/create', name: 'EventInAreaOfInterests' + 'Create', moduleId: PLATFORM.moduleName('pages/eventInAreaOfInterests/create'), nav: false, title: 'EventInAreaOfInterests Create'},
        {route: 'EventInAreaOfInterests/edit/:id', name: 'EventInAreaOfInterests' + 'Edit', moduleId: PLATFORM.moduleName('pages/eventInAreaOfInterests/edit'), nav: false, title: 'EventInAreaOfInterests Edit'},
        {route: 'EventInAreaOfInterests/delete/:id', name: 'EventInAreaOfInterests' + 'Delete', moduleId: PLATFORM.moduleName('pages/eventInAreaOfInterests/delete'), nav: false, title: 'EventInAreaOfInterests Delete'},
        {route: 'EventInAreaOfInterests/details/:id', name: 'EventInAreaOfInterests' + 'Details', moduleId: PLATFORM.moduleName('pages/eventInAreaOfInterests/details'), nav: false, title: 'EventInAreaOfInterests Details'},

        {route: ['Events','Events/index'], name: 'Events' + 'Index', moduleId: PLATFORM.moduleName('pages/events/index'), nav: true, title: 'Events'},
        {route: 'Events/create', name: 'Events' + 'Create', moduleId: PLATFORM.moduleName('pages/events/create'), nav: false, title: 'Events Create'},
        {route: 'Events/edit/:id', name: 'Events' + 'Edit', moduleId: PLATFORM.moduleName('pages/events/edit'), nav: false, title: 'Events Edit'},
        {route: 'Events/delete/:id', name: 'Events' + 'Delete', moduleId: PLATFORM.moduleName('pages/events/delete'), nav: false, title: 'Events Delete'},
        {route: 'Events/details/:id', name: 'Events' + 'Details', moduleId: PLATFORM.moduleName('pages/events/details'), nav: false, title: 'Events Details'},

        {route: ['EventInTypes','EventInTypes/index'], name: 'EventInTypes' + 'Index', moduleId: PLATFORM.moduleName('pages/eventInTypes/index'), nav: true, title: 'EventInTypes'},
        {route: 'EventInTypes/create', name: 'EventInTypes' + 'Create', moduleId: PLATFORM.moduleName('pages/eventInTypes/create'), nav: false, title: 'EventInTypes Create'},
        {route: 'EventInTypes/edit/:id', name: 'EventInTypes' + 'Edit', moduleId: PLATFORM.moduleName('pages/eventInTypes/edit'), nav: false, title: 'EventInTypes Edit'},
        {route: 'EventInTypes/delete/:id', name: 'EventInTypes' + 'Delete', moduleId: PLATFORM.moduleName('pages/eventInTypes/delete'), nav: false, title: 'EventInTypes Delete'},
        {route: 'EventInTypes/details/:id', name: 'EventInTypes' + 'Details', moduleId: PLATFORM.moduleName('pages/eventInTypes/details'), nav: false, title: 'EventInTypes Details'},

        {route: ['EventTypes','EventTypes/index'], name: 'EventTypes' + 'Index', moduleId: PLATFORM.moduleName('pages/eventTypes/index'), nav: true, title: 'EventTypes'},
        {route: 'EventTypes/create', name: 'EventTypes' + 'Create', moduleId: PLATFORM.moduleName('pages/eventTypes/create'), nav: false, title: 'EventTypes Create'},
        {route: 'EventTypes/edit/:id', name: 'EventTypes' + 'Edit', moduleId: PLATFORM.moduleName('pages/eventTypes/edit'), nav: false, title: 'EventTypes Edit'},
        {route: 'EventTypes/delete/:id', name: 'EventTypes' + 'Delete', moduleId: PLATFORM.moduleName('pages/eventTypes/delete'), nav: false, title: 'EventTypes Delete'},
        {route: 'EventTypes/details/:id', name: 'EventTypes' + 'Details', moduleId: PLATFORM.moduleName('pages/eventTypes/details'), nav: false, title: 'EventTypes Details'},

        {route: ['EventInLocations','EventInLocations/index'], name: 'EventInLocations' + 'Index', moduleId: PLATFORM.moduleName('pages/eventInLocations/index'), nav: true, title: 'EventInLocations'},
        {route: 'EventInLocations/create', name: 'EventInLocations' + 'Create', moduleId: PLATFORM.moduleName('pages/eventInLocations/create'), nav: false, title: 'EventInLocations Create'},
        {route: 'EventInLocations/edit/:id', name: 'EventInLocations' + 'Edit', moduleId: PLATFORM.moduleName('pages/eventInLocations/edit'), nav: false, title: 'EventInLocations Edit'},
        {route: 'EventInLocations/delete/:id', name: 'EventInLocations' + 'Delete', moduleId: PLATFORM.moduleName('pages/eventInLocations/delete'), nav: false, title: 'EventInLocations Delete'},
        {route: 'EventInLocations/details/:id', name: 'EventInLocations' + 'Details', moduleId: PLATFORM.moduleName('pages/eventInLocations/details'), nav: false, title: 'EventInLocations Details'},

        {route: ['Locations','Locations/index'], name: 'Locations' + 'Index', moduleId: PLATFORM.moduleName('pages/locations/index'), nav: true, title: 'Locations'},
        {route: 'Locations/create', name: 'Locations' + 'Create', moduleId: PLATFORM.moduleName('pages/locations/create'), nav: false, title: 'Locations Create'},
        {route: 'Locations/edit/:id', name: 'Locations' + 'Edit', moduleId: PLATFORM.moduleName('pages/locations/edit'), nav: false, title: 'Locations Edit'},
        {route: 'Locations/delete/:id', name: 'Locations' + 'Delete', moduleId: PLATFORM.moduleName('pages/locations/delete'), nav: false, title: 'Locations Delete'},
        {route: 'Locations/details/:id', name: 'Locations' + 'Details', moduleId: PLATFORM.moduleName('pages/locations/details'), nav: false, title: 'Locations Details'},

        {route: ['Organizations','Organizations/index'], name: 'Organizations' + 'Index', moduleId: PLATFORM.moduleName('pages/organizations/index'), nav: true, title: 'Organizations'},
        {route: 'Organizations/create', name: 'Organizations' + 'Create', moduleId: PLATFORM.moduleName('pages/organizations/create'), nav: false, title: 'Organizations Create'},
        {route: 'Organizations/edit/:id', name: 'Organizations' + 'Edit', moduleId: PLATFORM.moduleName('pages/organizations/edit'), nav: false, title: 'Organizations Edit'},
        {route: 'Organizations/delete/:id', name: 'Organizations' + 'Delete', moduleId: PLATFORM.moduleName('pages/organizations/delete'), nav: false, title: 'Organizations Delete'},
        {route: 'Organizations/details/:id', name: 'Organizations' + 'Details', moduleId: PLATFORM.moduleName('pages/organizations/details'), nav: false, title: 'Organizations Details'},

        {route: ['OrganizationOrganizings','OrganizationOrganizings/index'], name: 'OrganizationOrganizings' + 'Index', moduleId: PLATFORM.moduleName('pages/organizationOrganizings/index'), nav: true, title: 'OrganizationOrganizings'},
        {route: 'OrganizationOrganizings/create', name: 'OrganizationOrganizings' + 'Create', moduleId: PLATFORM.moduleName('pages/organizationOrganizings/create'), nav: false, title: 'OrganizationOrganizings Create'},
        {route: 'OrganizationOrganizings/edit/:id', name: 'OrganizationOrganizings' + 'Edit', moduleId: PLATFORM.moduleName('pages/organizationOrganizings/edit'), nav: false, title: 'OrganizationOrganizings Edit'},
        {route: 'OrganizationOrganizings/delete/:id', name: 'OrganizationOrganizings' + 'Delete', moduleId: PLATFORM.moduleName('pages/organizationOrganizings/delete'), nav: false, title: 'OrganizationOrganizings Delete'},
        {route: 'OrganizationOrganizings/details/:id', name: 'OrganizationOrganizings' + 'Details', moduleId: PLATFORM.moduleName('pages/organizationOrganizings/details'), nav: false, title: 'OrganizationOrganizings Details'},

        {route: ['SponsorInEvents','SponsorInEvents/index'], name: 'SponsorInEvents' + 'Index', moduleId: PLATFORM.moduleName('pages/sponsorInEvents/index'), nav: true, title: 'SponsorInEvents'},
        {route: 'SponsorInEvents/create', name: 'SponsorInEvents' + 'Create', moduleId: PLATFORM.moduleName('pages/sponsorInEvents/create'), nav: false, title: 'SponsorInEvents Create'},
        {route: 'SponsorInEvents/edit/:id', name: 'SponsorInEvents' + 'Edit', moduleId: PLATFORM.moduleName('pages/sponsorInEvents/edit'), nav: false, title: 'SponsorInEvents Edit'},
        {route: 'SponsorInEvents/delete/:id', name: 'SponsorInEvents' + 'Delete', moduleId: PLATFORM.moduleName('pages/sponsorInEvents/delete'), nav: false, title: 'SponsorInEvents Delete'},
        {route: 'SponsorInEvents/details/:id', name: 'SponsorInEvents' + 'Details', moduleId: PLATFORM.moduleName('pages/sponsorInEvents/details'), nav: false, title: 'SponsorInEvents Details'},

        {route: ['Performers','Performers/index'], name: 'Performers' + 'Index', moduleId: PLATFORM.moduleName('pages/performers/index'), nav: true, title: 'Performers'},
        {route: 'Performers/create', name: 'Performers' + 'Create', moduleId: PLATFORM.moduleName('pages/performers/create'), nav: false, title: 'Performers Create'},
        {route: 'Performers/edit/:id', name: 'Performers' + 'Edit', moduleId: PLATFORM.moduleName('pages/performers/edit'), nav: false, title: 'Performers Edit'},
        {route: 'Performers/delete/:id', name: 'Performers' + 'Delete', moduleId: PLATFORM.moduleName('pages/performers/delete'), nav: false, title: 'Performers Delete'},
        {route: 'Performers/details/:id', name: 'Performers' + 'Details', moduleId: PLATFORM.moduleName('pages/performers/details'), nav: false, title: 'Performers Details'},

        {route: ['PerformerInEvents','PerformerInEvents/index'], name: 'PerformerInEvents' + 'Index', moduleId: PLATFORM.moduleName('pages/performerInEvents/index'), nav: true, title: 'PerformerInEvents'},
        {route: 'PerformerInEvents/create', name: 'PerformerInEvents' + 'Create', moduleId: PLATFORM.moduleName('pages/performerInEvents/create'), nav: false, title: 'PerformerInEvents Create'},
        {route: 'PerformerInEvents/edit/:id', name: 'PerformerInEvents' + 'Edit', moduleId: PLATFORM.moduleName('pages/performerInEvents/edit'), nav: false, title: 'PerformerInEvents Edit'},
        {route: 'PerformerInEvents/delete/:id', name: 'PerformerInEvents' + 'Delete', moduleId: PLATFORM.moduleName('pages/performerInEvents/delete'), nav: false, title: 'PerformerInEvents Delete'},
        {route: 'PerformerInEvents/details/:id', name: 'PerformerInEvents' + 'Details', moduleId: PLATFORM.moduleName('pages/performerInEvents/details'), nav: false, title: 'PerformerInEvents Details'},

        {route: ['EventTargetAudiences','EventTargetAudiences/index'], name: 'EventTargetAudiences' + 'Index', moduleId: PLATFORM.moduleName('pages/eventTargetAudiences/index'), nav: true, title: 'EventTargetAudiences'},
        {route: 'EventTargetAudiences/create', name: 'EventTargetAudiences' + 'Create', moduleId: PLATFORM.moduleName('pages/eventTargetAudiences/create'), nav: false, title: 'EventTargetAudiences Create'},
        {route: 'EventTargetAudiences/edit/:id', name: 'EventTargetAudiences' + 'Edit', moduleId: PLATFORM.moduleName('pages/eventTargetAudiences/edit'), nav: false, title: 'EventTargetAudiences Edit'},
        {route: 'EventTargetAudiences/delete/:id', name: 'EventTargetAudiences' + 'Delete', moduleId: PLATFORM.moduleName('pages/eventTargetAudiences/delete'), nav: false, title: 'EventTargetAudiences Delete'},
        {route: 'EventTargetAudiences/details/:id', name: 'EventTargetAudiences' + 'Details', moduleId: PLATFORM.moduleName('pages/eventTargetAudiences/details'), nav: false, title: 'EventTargetAudiences Details'},

        {route: ['TargetAudiences','TargetAudiences/index'], name: 'TargetAudiences' + 'Index', moduleId: PLATFORM.moduleName('pages/targetAudiences/index'), nav: true, title: 'TargetAudiences'},
        {route: 'TargetAudiences/create', name: 'TargetAudiences' + 'Create', moduleId: PLATFORM.moduleName('pages/targetAudiences/create'), nav: false, title: 'TargetAudiences Create'},
        {route: 'TargetAudiences/edit/:id', name: 'TargetAudiences' + 'Edit', moduleId: PLATFORM.moduleName('pages/targetAudiences/edit'), nav: false, title: 'TargetAudiences Edit'},
        {route: 'TargetAudiences/delete/:id', name: 'TargetAudiences' + 'Delete', moduleId: PLATFORM.moduleName('pages/targetAudiences/delete'), nav: false, title: 'TargetAudiences Delete'},
        {route: 'TargetAudiences/details/:id', name: 'TargetAudiences' + 'Details', moduleId: PLATFORM.moduleName('pages/targetAudiences/details'), nav: false, title: 'TargetAudiences Details'},

      ]
    );

  }

}
